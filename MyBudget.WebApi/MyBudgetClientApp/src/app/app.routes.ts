import { Routes } from '@angular/router';
import {ACCOUNTS_PAGE_ADDRESS, ANALYTICS_PAGE_ADDRESS, TRANSACTIONS_PAGE_ADDRESS} from './shared/consts';
import {TransactionsComponent} from './transactions/transactions.component';
import {AnalyticsComponent} from './analytics/analytics.component';
import {AccountsComponent} from './accounts/accounts.component';

export const routes: Routes = [
  {path: TRANSACTIONS_PAGE_ADDRESS, component: TransactionsComponent},
  {path: ANALYTICS_PAGE_ADDRESS, component: AnalyticsComponent},
  {path: ACCOUNTS_PAGE_ADDRESS, component: AccountsComponent},
];
