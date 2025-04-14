import {Component} from '@angular/core';
import {RouterOutlet} from '@angular/router';
import {NavBarComponent} from './nav-bar/nav-bar.component';
import {DialogContainerDirective} from '@progress/kendo-angular-dialog';
import {LoaderComponent} from './shared/components/loader/loader.component';
import {NotificationContainerComponent} from '@progress/kendo-angular-notification';

@Component({
  selector: 'app-root',
  imports: [RouterOutlet, NavBarComponent, DialogContainerDirective, LoaderComponent, NotificationContainerComponent],
  templateUrl: './app.component.html',
  styleUrl: './app.component.scss'
})
export class AppComponent {
}
