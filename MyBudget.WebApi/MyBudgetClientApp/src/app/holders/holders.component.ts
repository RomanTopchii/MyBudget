import {Component, OnInit} from '@angular/core';
import {CurrencyService} from '../shared/http-services/currency.service';
import {HttpClient} from '@angular/common/http';
import {CurrencySimpleDto, HolderSimpleDto} from '../shared/http-services/responses';
import {
  GridModule,
  SelectableSettings
} from '@progress/kendo-angular-grid';
import {pencilIcon, plusIcon, SVGIcon, trashIcon} from '@progress/kendo-svg-icons';
import {ButtonComponent} from '@progress/kendo-angular-buttons';
import {DialogService} from '@progress/kendo-angular-dialog';
import {HolderDialogComponent} from './holder-dialog/holder-dialog.component';
import {LoaderService} from '../shared/loader.service';
import {HolderService} from '../shared/http-services/holder.service';

@Component({
  selector: 'app-holders',
  imports: [
    GridModule,
    ButtonComponent,
  ],
  providers: [HttpClient],
  templateUrl: './holders.component.html',
  styleUrl: './holders.component.scss'
})
export class HoldersComponent
  implements OnInit {
  protected data: HolderSimpleDto[] = [];

  protected selectedHolder: HolderSimpleDto | null = null;

  protected readonly plusIcon = plusIcon;
  protected readonly pencilIcon: SVGIcon = pencilIcon;
  protected readonly trashIcon = trashIcon;
  protected readonly selectableSettings: SelectableSettings = {
    mode: 'single',
  };

  constructor(private holderService: HolderService,
              private loaderService: LoaderService,
              private dialogService: DialogService) {
  }

  ngOnInit() {
    this.loadData();
  }

  private loadData() {
    this.loaderService.showLoader();
    this.holderService.getHolders().subscribe({
      next: (result) => {
        this.data = result
        this.loaderService.hideLoader();
      },
      error: _ => {
        this.loaderService.hideLoader();
      }
    });
  }

  protected selectItem(event: any): void {
    this.selectedHolder = event.selectedRows[0].dataItem;
  }

  protected onEditClick() {
    if (!this.selectedHolder) {
      return;
    }

      const dialogReg = this.dialogService.open({content: HolderDialogComponent});
    dialogReg.result.subscribe(result => {
      if (result == true) {
        this.loadData();
      }
    });

    const instance = dialogReg.content.instance as HolderDialogComponent;
    instance.holderId = this.selectedHolder?.id ?? null;
  }

  protected onAddClick() {
    const dialogRef = this.dialogService.open({content: HolderDialogComponent});
    dialogRef.result.subscribe(result => {
      if (result == true) {
        this.ngOnInit()
      }
    });
  }

  protected onDeleteClick() {
    if (!this.selectedHolder) {
      return;
    }

    const actions = [
      {text: 'Yes', themeColor: 'error'},
      {text: 'No'}
    ];

    const dialogRef = this.dialogService.open({
      title: 'Delete holder',
      content: `Do you want to delete "${this.selectedHolder.name}" holder?`,
      actions: actions
    });

    dialogRef.result.subscribe(result => {
      if (result == actions[0]) {
        this.loaderService.showLoader();

        this.holderService.deleteHolder(this.selectedHolder!.id).subscribe({
          next: _ => {
            this.loadData();
          }
        });
      }
    });
  }
}
