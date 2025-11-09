import { Routes } from '@angular/router';
import {
  ACCOUNT_TYPES_PAGE_ADDRESS,
  ACCOUNTS_PAGE_ADDRESS,
  ANALYTICS_PAGE_ADDRESS,
  CURRENCIES_PAGE_ADDRESS, HOLDERS_PAGE_ADDRESS, KEEPERS_PAGE_ADDRESS,
  TRANSACTIONS_PAGE_ADDRESS
} from './shared/consts';
import {TransactionsComponent} from './transactions/transactions.component';
import {AnalyticsComponent} from './analytics/analytics.component';
import {AccountsComponent} from './accounts/accounts.component';
import {CurrenciesComponent} from './currencies/currencies.component';
import {HoldersComponent} from './holders/holders.component';
import {KeepersComponent} from './keepers/keepers.component';
import {AccountTypesComponent} from './account-types/account-types.component';

export const routes: Routes = [
  {path: TRANSACTIONS_PAGE_ADDRESS, component: TransactionsComponent},
  {path: ANALYTICS_PAGE_ADDRESS, component: AnalyticsComponent},
  {path: ACCOUNTS_PAGE_ADDRESS, component: AccountsComponent},
  {path: CURRENCIES_PAGE_ADDRESS, component: CurrenciesComponent},
  {path: HOLDERS_PAGE_ADDRESS, component: HoldersComponent},
  {path: KEEPERS_PAGE_ADDRESS, component: KeepersComponent},
  {path: ACCOUNT_TYPES_PAGE_ADDRESS, component: AccountTypesComponent},
];
