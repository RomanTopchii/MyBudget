import {Component, OnInit} from '@angular/core';
import {CurrencyService} from '../../shared/http-services/currency.service';
import {HttpClient} from '@angular/common/http';
import {CurrencySimpleDto} from '../../shared/http-services/responses';
import {Guid} from '../../shared/common/Guid';
import {DialogContentBase, DialogRef, DialogsModule} from '@progress/kendo-angular-dialog';
import {SaveCurrencyCommand} from '../../shared/http-services/requests';
import {FloatingLabelComponent, LabelComponent} from '@progress/kendo-angular-label';
import {CheckBoxDirective, TextBoxComponent} from '@progress/kendo-angular-inputs';
import {FormControl, FormGroup, ReactiveFormsModule, Validators} from '@angular/forms';
import {ButtonModule} from '@progress/kendo-angular-buttons';

@Component({
  selector: 'app-currency-dialog',
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
  templateUrl: './currency-dialog.component.html',
  styleUrl: './currency-dialog.component.scss'
})
export class CurrencyDialogComponent
  extends DialogContentBase
  implements OnInit {

  public currencyId: Guid | null = null;

  protected currency: CurrencySimpleDto | null = null;

  protected formGroup = new FormGroup({
    code: new FormControl('', [Validators.required, Validators.minLength(3), Validators.maxLength(3)]),
    iso4217: new FormControl(0, [Validators.required, Validators.minLength(3), Validators.maxLength(3)]),
    active: new FormControl(true, Validators.required),
  })

  constructor(private service: CurrencyService,
              private dialogRef: DialogRef) {
    super(dialogRef);
    this.formGroup.controls.iso4217.patchValue(null);
  }

  protected get confirmButtonTitle(): string {
    return this.currencyId == null ? "Create" : "Save"
  }

  protected get title(): string {
    return this.currencyId == null ? "Create currency" : "Edit currency"
  }

  ngOnInit() {
    if (!this.currencyId) {
      return;
    }
    this.service.getCurrencyById(this.currencyId!).subscribe({
      next: (result) => {
        this.currency = result;
        this.formGroup.controls.code.patchValue(result.code);
        this.formGroup.controls.active.patchValue(result.active);
        this.formGroup.controls.iso4217.patchValue(result.iso4217);
      },
      error: (err) => {
        this.dialog.close(true);
      }
    });
  }

  protected onConfirmClick() {
    const command: SaveCurrencyCommand = {
      id: this.currencyId,
      active: this.formGroup.controls.active.value as boolean,
      code: this.formGroup.controls.code.value as string,
      iso4217: this.formGroup.controls.iso4217.value as unknown as number
    };

    this.service.saveCurrency(command).subscribe({
      next: (result) => {
        this.dialog.close(true);
      },
      error: (err) => {
        this.dialog.close(false);
      }
    });
  }

  protected closeClick() {
    this.dialog.close(false);
  }
}
