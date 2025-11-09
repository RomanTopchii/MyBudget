import { Component } from '@angular/core';
import {
  ACCOUNT_TYPES_PAGE_ADDRESS,
  ACCOUNTS_PAGE_ADDRESS,
  ANALYTICS_PAGE_ADDRESS,
  CURRENCIES_PAGE_ADDRESS, HOLDERS_PAGE_ADDRESS, KEEPERS_PAGE_ADDRESS,
  TRANSACTIONS_PAGE_ADDRESS
} from '../shared/consts';
import {AppBarComponent, AppBarSectionComponent, AppBarSpacerComponent} from '@progress/kendo-angular-navigation';
import {RouterLink, RouterLinkActive} from '@angular/router';

@Component({
  selector: 'app-nav-bar',
  imports: [
    AppBarSectionComponent,
    AppBarComponent,
    AppBarSpacerComponent,
    RouterLink,
    RouterLinkActive,
  ],
  templateUrl: './nav-bar.component.html',
  styleUrl: './nav-bar.component.scss'
})
export class NavBarComponent {
  protected readonly TRANSACTIONS_PAGE_ADDRESS = TRANSACTIONS_PAGE_ADDRESS;
  protected readonly ANALYTICS_PAGE_ADDRESS = ANALYTICS_PAGE_ADDRESS;
  protected readonly ACCOUNTS_PAGE_ADDRESS = ACCOUNTS_PAGE_ADDRESS;
  protected readonly CURRENCIES_PAGE_ADDRESS = CURRENCIES_PAGE_ADDRESS;
  protected readonly HOLDERS_PAGE_ADDRESS = HOLDERS_PAGE_ADDRESS;
  protected readonly KEEPERS_PAGE_ADDRESS = KEEPERS_PAGE_ADDRESS;
  protected readonly ACCOUNT_TYPES_PAGE_ADDRESS = ACCOUNT_TYPES_PAGE_ADDRESS;
}
