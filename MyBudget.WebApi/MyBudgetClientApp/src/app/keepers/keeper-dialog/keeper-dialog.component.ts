import {Component, OnInit} from '@angular/core';
import {HttpClient} from '@angular/common/http';
import {KeeperSimpleDto} from '../../shared/http-services/responses';
import {Guid} from '../../shared/common/Guid';
import {DialogContentBase, DialogRef, DialogsModule} from '@progress/kendo-angular-dialog';
import {KeeperType, SaveKeeper} from '../../shared/http-services/requests';
import {FormControl, FormGroup, ReactiveFormsModule, Validators} from '@angular/forms';
import {ButtonGroupComponent, ButtonModule} from '@progress/kendo-angular-buttons';
import {FloatingLabelComponent, LabelComponent} from '@progress/kendo-angular-label';
import {TextBoxComponent} from '@progress/kendo-angular-inputs';
import {KeeperService} from '../../shared/http-services/keeper.service';

@Component({
  selector: 'app-keeper-dialog',
  imports: [
    ButtonModule,
    DialogsModule,
    ReactiveFormsModule,
    LabelComponent,
    FloatingLabelComponent,
    TextBoxComponent,
    ButtonGroupComponent
  ],
  providers: [HttpClient],
  templateUrl: './keeper-dialog.component.html',
  styleUrl: './keeper-dialog.component.scss'
})
export class KeeperDialogComponent
  extends DialogContentBase
  implements OnInit {

  public keeperId: Guid | null = null;

  protected keeper: KeeperSimpleDto | null = null;

  protected selectedKeeperType: KeeperType = KeeperType.Cash;

  protected formGroup = new FormGroup({
    name: new FormControl('', Validators.required),
    active: new FormControl(true, Validators.required)
  })

  constructor(private service: KeeperService,
              private dialogRef: DialogRef) {
    super(dialogRef);
  }

  protected get confirmButtonTitle(): string {
    return this.keeperId == null ? "Create" : "Save"
  }

  protected get title(): string {
    return this.keeper == null ? "Create keeper" : "Edit keeper"
  }

  ngOnInit() {
    if (!this.keeperId) {
      return;
    }
    this.service.getKeeperById(this.keeperId!).subscribe({
      next: (result) => {
        this.keeper = result;
        this.selectedKeeperType = result.type;
        this.formGroup.controls.name.patchValue(result.name);
        this.formGroup.controls.active.patchValue(result.active);
      },
      error: _ => {
        this.dialog.close(true);
      }
    });
  }

  protected onTypeChangeClick(keeperType: KeeperType) {
    this.selectedKeeperType = keeperType;
  }

  protected onConfirmClick() {
    const command: SaveKeeper = {
      id: this.keeperId,
      active: this.formGroup.controls.active.value as boolean,
      name: this.formGroup.controls.name.value as string,
      type: this.selectedKeeperType
    };

    this.service.saveKeeper(command).subscribe({
      next: _ => {
        this.dialog.close(true);
      },
      error: _ => {
        this.dialog.close(false);
      }
    });
  }

  protected closeClick() {
    this.dialog.close(false);
  }

  protected readonly KeeperType = KeeperType;
}
