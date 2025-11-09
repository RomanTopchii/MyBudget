import {Component, OnInit} from '@angular/core';
import {AccountTypeRichDto} from '../shared/http-services/responses';
import {ColumnComponent, GridComponent} from '@progress/kendo-angular-grid';
import {AccountTypeService} from '../shared/http-services/account-type.service';
import {LoaderService} from '../shared/loader.service';
import {DialogService} from '@progress/kendo-angular-dialog';
import {AccountTypeDetailsComponent} from './account-type-details/account-type-details.component';
import {Guid} from '../shared/common/Guid';

@Component({
  selector: 'app-account-types',
  imports: [
    GridComponent,
    ColumnComponent,
    AccountTypeDetailsComponent
  ],
  templateUrl: './account-types.component.html',
  styleUrl: './account-types.component.scss'
})
export class AccountTypesComponent
  implements OnInit {
  accountTypes: AccountTypeRichDto[] = [];

  selectedAccountType: AccountTypeRichDto | null = null;

  constructor(private accountTypeService: AccountTypeService,
              private loaderService: LoaderService,
              private dialogService: DialogService) {
  }

  ngOnInit(): void {
    this.loadData();
  }

  onSelectionChange(event: any): void {
    this.selectedAccountType = event.selectedRows[0]?.dataItem || null;
  }

  private loadData() {
    this.loaderService.showLoader();
    this.accountTypeService.getAccountTypes().subscribe({
      next: (result) => {
        this.accountTypes = result;
        this.selectedAccountType = result[0];
        this.loaderService.hideLoader();
      },
      error: _ => {
        this.loaderService.hideLoader();
      }
    });
  }

  protected readonly Guid = Guid;
}
