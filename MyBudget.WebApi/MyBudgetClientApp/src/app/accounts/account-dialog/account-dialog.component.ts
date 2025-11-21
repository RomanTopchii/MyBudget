import {Component, OnInit} from '@angular/core';
import {HttpClient} from '@angular/common/http';
import {
  AccountSimpleDto,
  AccountTypeNamedDto,
  AccountTypeRichDto,
  CurrencySimpleDto, HolderSimpleDto, KeeperSimpleDto
} from '../../shared/http-services/responses';
import {Guid} from '../../shared/common/Guid';
import {DialogContentBase, DialogRef, DialogsModule} from '@progress/kendo-angular-dialog';
import {SaveAccount} from '../../shared/http-services/requests';
import {FloatingLabelComponent, LabelComponent} from '@progress/kendo-angular-label';
import {CheckBoxDirective, TextBoxComponent} from '@progress/kendo-angular-inputs';
import {FormControl, FormGroup, ReactiveFormsModule, Validators} from '@angular/forms';
import {ButtonModule} from '@progress/kendo-angular-buttons';
import {forkJoin} from 'rxjs';
import {AccountTypeService} from '../../shared/http-services/account-type.service';
import {AccountService} from '../../shared/http-services/account.service';
import {CurrencyService} from '../../shared/http-services/currency.service';
import {KeeperService} from '../../shared/http-services/keeper.service';
import {HolderService} from '../../shared/http-services/holder.service';

@Component({
  selector: 'app-account-dialog',
  imports: [
    ButtonModule,
    DialogsModule,
    FloatingLabelComponent,
    TextBoxComponent,
    ReactiveFormsModule,
    CheckBoxDirective,
    LabelComponent,
  ],
  providers: [HttpClient],
  templateUrl: './account-dialog.component.html',
  styleUrl: './account-dialog.component.scss'
})
export class AccountDialogComponent
  extends DialogContentBase
  implements OnInit {

  public accountId: Guid | null = null;

  protected account: AccountSimpleDto | null = null;
  protected accountTypes: AccountTypeRichDto[] = [];
  protected currencies: CurrencySimpleDto[] = [];
  protected keepers: KeeperSimpleDto[] = [];
  protected holders: HolderSimpleDto[] = [];

  protected formGroup = new FormGroup({
    name: new FormControl('', [Validators.required, Validators.minLength(3), Validators.maxLength(255)]),
    active: new FormControl(true, Validators.required),
    type: new FormControl(null, Validators.required),
    parent: new FormControl(null),
    currency: new FormControl(null),
    keeper: new FormControl(null),
    holder: new FormControl(null)
  })

  constructor(private accountService: AccountService,
              private accountTypeService: AccountTypeService,
              private currencyService: CurrencyService,
              private keeperService: KeeperService,
              private holderService: HolderService,
              private dialogRef: DialogRef) {
    super(dialogRef);
    //this.formGroup.controls.iso4217.patchValue(null);
  }

  protected get confirmButtonTitle(): string {
    return this.accountId == null ? "Create" : "Save"
  }

  protected get title(): string {
    return this.accountId == null ? "Create account" : "Edit account"
  }

  ngOnInit() {
    if (!this.accountId) {
      return;
    }

    forkJoin([
      this.accountService.getAccountById(this.accountId!),
      this.accountTypeService.getAccountTypes(),
      this.currencyService.getCurrencies(),
      this.keeperService.getKeepers(),
      this.holderService.getHolders(),
    ])
      .subscribe({
        next: ([account, accountTypes, currencies, keepers, holders]) => {
          this.account = account;
          this.accountTypes = accountTypes;
          this.currencies = currencies;
          this.keepers = keepers;
          this.holders = holders;
          this.formGroup.controls.name.patchValue(account.name);
          this.formGroup.controls.active.patchValue(account.active);
        },
        error: _ => {
          this.dialog.close(true);
        }
      });
  }

  protected onConfirmClick() {
    // const command: SaveAccount = {
    //   id: this.AccountId,
    //   active: this.formGroup.controls.active.value as boolean,
    //   code: this.formGroup.controls.code.value as string,
    //   iso4217: this.formGroup.controls.iso4217.value as unknown as number
    // };
    //
    // this.accountService.saveAccount(command).subscribe({
    //   next: _ => {
    //     this.dialog.close(true);
    //   },
    //   error: _ => {
    //     this.dialog.close(false);
    //   }
    // });
  }

  protected closeClick() {
    this.dialog.close(false);
  }
}
