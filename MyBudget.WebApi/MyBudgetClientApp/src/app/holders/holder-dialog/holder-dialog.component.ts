import {Component, OnInit} from '@angular/core';
import {HttpClient} from '@angular/common/http';
import {HolderSimpleDto} from '../../shared/http-services/responses';
import {Guid} from '../../shared/common/Guid';
import {DialogContentBase, DialogRef, DialogsModule} from '@progress/kendo-angular-dialog';
import {SaveHolder} from '../../shared/http-services/requests';
import {FormControl, FormGroup, ReactiveFormsModule, Validators} from '@angular/forms';
import {ButtonModule} from '@progress/kendo-angular-buttons';
import {HolderService} from '../../shared/http-services/holder.service';
import {FloatingLabelComponent, LabelComponent} from '@progress/kendo-angular-label';
import {TextBoxComponent} from '@progress/kendo-angular-inputs';

@Component({
  selector: 'app-holder-dialog',
  imports: [
    ButtonModule,
    DialogsModule,
    ReactiveFormsModule,
    LabelComponent,
    FloatingLabelComponent,
    TextBoxComponent
  ],
  providers: [HttpClient],
  templateUrl: './holder-dialog.component.html',
  styleUrl: './holder-dialog.component.scss'
})
export class HolderDialogComponent
  extends DialogContentBase
  implements OnInit {

  public holderId: Guid | null = null;

  protected holder: HolderSimpleDto | null = null;

  protected formGroup = new FormGroup({
    name: new FormControl('', Validators.required),
    active: new FormControl(true, Validators.required)
  })

  constructor(private service: HolderService,
              private dialogRef: DialogRef) {
    super(dialogRef);
  }

  protected get confirmButtonTitle(): string {
    return this.holderId == null ? "Create" : "Save"
  }

  protected get title(): string {
    return this.holderId == null ? "Create holder" : "Edit holder"
  }

  ngOnInit() {
    if (!this.holderId) {
      return;
    }
    this.service.getHolderById(this.holderId!).subscribe({
      next: (result) => {
        this.holder = result;
        this.formGroup.controls.name.patchValue(result.name);
        this.formGroup.controls.active.patchValue(result.active);
      },
      error: _ => {
        this.dialog.close(true);
      }
    });
  }

  protected onConfirmClick() {
    const command: SaveHolder = {
      id: this.holderId,
      active: this.formGroup.controls.active.value as boolean,
      name: this.formGroup.controls.name.value as string,
    };

    this.service.saveHolder(command).subscribe({
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
}
