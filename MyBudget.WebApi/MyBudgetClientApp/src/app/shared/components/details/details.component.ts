import {Component, Input} from '@angular/core';
import {ColumnComponent, GridComponent} from '@progress/kendo-angular-grid';

@Component({
  selector: 'app-details',
  imports: [
    GridComponent,
    ColumnComponent
  ],
  templateUrl: './details.component.html',
  styleUrl: './details.component.scss'
})
export class DetailsComponent {
  @Input() public data: { [key: string]: any } = {};
  @Input() public firstColumnWidth : number = 250;

  get entries(): { key: string; value: any }[] {
    return Object.entries(this.data).map(([key, value]) => ({ key, value }));
  }
}
