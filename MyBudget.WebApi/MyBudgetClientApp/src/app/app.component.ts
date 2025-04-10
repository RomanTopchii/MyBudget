import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import {NavBarComponent} from './nav-bar/nav-bar.component';
import {DialogContainerDirective} from '@progress/kendo-angular-dialog';

@Component({
  selector: 'app-root',
  imports: [RouterOutlet, NavBarComponent, DialogContainerDirective],
  templateUrl: './app.component.html',
  styleUrl: './app.component.scss'
})
export class AppComponent {
  title = 'mybudget-client-app';
}
