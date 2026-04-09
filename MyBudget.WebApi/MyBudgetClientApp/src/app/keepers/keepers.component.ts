import {Component, OnInit} from '@angular/core';
import {HttpClient} from '@angular/common/http';
import {KeeperSimpleDto} from '../shared/http-services/responses';
import {
  GridModule,
  SelectableSettings
} from '@progress/kendo-angular-grid';
import {pencilIcon, plusIcon, SVGIcon, trashIcon} from '@progress/kendo-svg-icons';
import {ButtonComponent} from '@progress/kendo-angular-buttons';
import {DialogService} from '@progress/kendo-angular-dialog';
import {KeeperDialogComponent} from './keeper-dialog/keeper-dialog.component';
import {LoaderService} from '../shared/loader.service';
import {KeeperService} from '../shared/http-services/keeper.service';
import {KeeperType} from '../shared/http-services/requests';

@Component({
  selector: 'app-keepers',
  imports: [
    GridModule,
    ButtonComponent,
  ],
  providers: [HttpClient],
  templateUrl: './keepers.component.html',
  styleUrl: './keepers.component.scss'
})
export class KeepersComponent
  implements OnInit {
  protected data: KeeperSimpleDto[] = [];

  protected selectedKeeper: KeeperSimpleDto | null = null;

  protected readonly plusIcon = plusIcon;
  protected readonly pencilIcon: SVGIcon = pencilIcon;
  protected readonly trashIcon = trashIcon;
  protected readonly selectableSettings: SelectableSettings = {
    mode: 'single',
  };

  constructor(private KeeperService: KeeperService,
              private loaderService: LoaderService,
              private dialogService: DialogService) {
  }

  ngOnInit() {
    this.loadData();
  }

  private loadData() {
    this.loaderService.showLoader();
    this.KeeperService.getKeepers().subscribe({
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
    this.selectedKeeper = event.selectedRows[0].dataItem;
  }

  protected onEditClick() {
    if (!this.selectedKeeper) {
      return;
    }

      const dialogReg = this.dialogService.open({content: KeeperDialogComponent});
    dialogReg.result.subscribe(result => {
      if (result == true) {
        this.loadData();
      }
    });

    const instance = dialogReg.content.instance as KeeperDialogComponent;
    instance.keeperId = this.selectedKeeper?.id ?? null;
  }

  protected onAddClick() {
    const dialogRef = this.dialogService.open({content: KeeperDialogComponent});
    dialogRef.result.subscribe(result => {
      if (result == true) {
        this.ngOnInit()
      }
    });
  }

  protected onDeleteClick() {
    if (!this.selectedKeeper) {
      return;
    }

    const actions = [
      {text: 'Yes', themeColor: 'error'},
      {text: 'No'}
    ];

    const dialogRef = this.dialogService.open({
      title: 'Delete Keeper',
      content: `Do you want to delete "${this.selectedKeeper.name}" keeper?`,
      actions: actions
    });

    dialogRef.result.subscribe(result => {
      if (result == actions[0]) {
        this.loaderService.showLoader();

        this.KeeperService.deleteKeeper(this.selectedKeeper!.id).subscribe({
          next: _ => {
            this.loadData();
          }
        });
      }
    });
  }

  protected readonly KeeperType = KeeperType;
}
