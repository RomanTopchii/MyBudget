import {Component, OnInit} from '@angular/core';
import {CurrencyService} from '../shared/http-services/currency.service';
import {HttpClient} from '@angular/common/http';
import {CurrencySimpleDto} from '../shared/http-services/responses';
import {
  GridModule,
  SelectableSettings
} from '@progress/kendo-angular-grid';
import {pencilIcon, plusIcon, SVGIcon, trashIcon} from '@progress/kendo-svg-icons';
import {ButtonComponent} from '@progress/kendo-angular-buttons';
import {DialogService} from '@progress/kendo-angular-dialog';
import {CurrencyDialogComponent} from './currency-dialog/currency-dialog.component';

@Component({
  selector: 'app-currencies',
  imports: [
    GridModule,
    ButtonComponent,
  ],
  providers: [HttpClient],
  templateUrl: './currencies.component.html',
  styleUrl: './currencies.component.scss'
})
export class CurrenciesComponent
  implements OnInit {
  protected data: CurrencySimpleDto[] = [];

  protected selectedCurrency: CurrencySimpleDto | null = null;

  protected readonly plusIcon = plusIcon;
  protected readonly pencilIcon: SVGIcon = pencilIcon;
  protected readonly trashIcon = trashIcon;
  protected readonly selectableSettings: SelectableSettings = {
    mode: 'single',
  };

  constructor(private service: CurrencyService,
              private dialogService: DialogService) {
  }

  ngOnInit() {
    this.loadData();
  }

  private loadData() {
    this.service.getCurrencies().subscribe({
      next: (result) => this.data = result,
      error: (err) => {
      }
    });
  }

  protected selectItem(event: any): void {
    this.selectedCurrency = event.selectedRows[0].dataItem;
    console.log(this.selectedCurrency);
  }

  protected onEditClick() {
    if (!this.selectedCurrency) {
      return;
    }

    const dialogReg = this.dialogService.open({content: CurrencyDialogComponent});
    dialogReg.result.subscribe(result => {
      if (result == true) {
        this.ngOnInit()
      }
    });

    const instance = dialogReg.content.instance as CurrencyDialogComponent;
    instance.currencyId = this.selectedCurrency?.id ?? null;
  }

  protected onAddClick() {
    const dialogRef = this.dialogService.open({content: CurrencyDialogComponent});
    dialogRef.result.subscribe(result => {
      if (result == true) {
        this.ngOnInit()
      }
    });
  }

  protected onDeleteClick() {
    if (!this.selectedCurrency) {
      return;
    }

    const actions = [
      {text: 'Yes', themeColor: 'error'},
      {text: 'No'}
    ];

    const dialogRef = this.dialogService.open({
      title: 'Delete currency',
      content: `Do you want to delete "${this.selectedCurrency.code}" currency?`,
      actions: actions
    });

    dialogRef.result.subscribe(result => {
      if (result == actions[0]) {
        this.service.deleteCurrency(this.selectedCurrency!.id).subscribe({
          next: (result) => {
            this.loadData();
          },
          error: (err) => {
          }
        });
      }
    });
  }
}
