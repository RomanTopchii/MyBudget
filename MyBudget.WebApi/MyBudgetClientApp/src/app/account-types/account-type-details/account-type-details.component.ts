import {Component, Input} from '@angular/core';
import {AccountTypeRichDto} from '../../shared/http-services/responses';
import {DetailsComponent} from '../../shared/components/details/details.component';
import {AccountTypeService} from '../../shared/http-services/account-type.service';
import {LoaderService} from '../../shared/loader.service';
import {ButtonComponent, ButtonGroupComponent} from '@progress/kendo-angular-buttons';
import {KeeperGroup} from '../../shared/http-services/requests';
import {PickOption} from './pick-option';
import {ColumnComponent, GridComponent} from '@progress/kendo-angular-grid';

@Component({
  selector: 'app-account-type-details',
  imports: [
    DetailsComponent,
    ButtonComponent,
    ButtonGroupComponent,
    ColumnComponent,
    GridComponent
  ],
  templateUrl: './account-type-details.component.html',
  styleUrl: './account-type-details.component.scss'
})
export class AccountTypeDetailsComponent {

  @Input() public selectedAccountType: AccountTypeRichDto | null = null;

  protected pickOptions: PickOption[] = [
    PickOption.Details,
    PickOption.Ancestors,
    PickOption.Children,
    PickOption.Info];

  protected selectedOption = PickOption.Details;

  constructor(private accountTypeService: AccountTypeService,
              private loaderService: LoaderService) {

  }

  onSelectionChange(event: any): void {
    this.selectedAccountType = event.selectedRows[0]?.dataItem || null;
  }

  protected get getDetailsBasedOnOption() {
    if (this.selectedOption == PickOption.Details) {
      return this.getDetails();
    } else if (this.selectedOption == PickOption.Info) {
      return this.getTechnicalInfo();
    }

    return {'': ''};
  }

  private getDetails() {
    return {
      'Name': this.selectedAccountType?.name,
      'Active': this.selectedAccountType?.active,
      'Can be renamed': this.selectedAccountType?.canBeRenamed,
      'Can change active status': this.selectedAccountType?.canChangeActiveStatus,
      'Can be deleted': this.selectedAccountType?.canBeDeleted,
      'Can be created by user': this.selectedAccountType?.canBeCreatedByUser,
      'Has currency': this.selectedAccountType?.hasCurrency,
      'Has keeper': this.selectedAccountType?.hasKeeper,
      'Has holder': this.selectedAccountType?.hasHolder,
      'Has initial balance': this.selectedAccountType?.hasInitialBalance,
      'Calculate full-time balance': this.selectedAccountType?.calcFullTimeBalance,
      'Check amount before deactivate': this.selectedAccountType?.checkAmountBeforeDeactivate,
      'Allows transactions': this.selectedAccountType?.allowsTransactions,
      'Keeper group': this.getKeeperGroup(this.selectedAccountType?.keeperGroup),
      'Priority': this.selectedAccountType?.priority
    }
  }

  private getTechnicalInfo() {
    return {
      'Create date': this.selectedAccountType?.createDate,
      'Created by': this.selectedAccountType?.createdBy,
      'Modify date': this.selectedAccountType?.modifyDate,
      'Modified by': this.selectedAccountType?.modifiedBy
    }
  }

  private getKeeperGroup(group: KeeperGroup | undefined | null) {
    if (group == null) {
      return '';
    }

    switch (group) {
      case KeeperGroup.None:
        return 'None';
      case KeeperGroup.Cash:
        return 'Cash';
      case KeeperGroup.Bank:
        return 'Bank';
      case KeeperGroup.NonCash:
        return 'Non cash';
      case KeeperGroup.Any:
        return 'Any';
    }
  }

  private loadData() {
    this.loaderService.showLoader();
    this.accountTypeService.getAccountTypeById(this.selectedAccountType!.id).subscribe({
      next: (result) => {
        this.selectedAccountType = result
        this.loaderService.hideLoader();
      },
      error: _ => {
        this.loaderService.hideLoader();
      }
    });
  }

  protected readonly PickOption = PickOption;
}
