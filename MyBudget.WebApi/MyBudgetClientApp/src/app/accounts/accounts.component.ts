import { Component } from '@angular/core';
import {TreeViewComponent} from '@progress/kendo-angular-treeview';
import {AccountRichDto} from '../shared/http-services/responses';
import {AccountService} from '../shared/http-services/account.service';
import {LoaderService} from '../shared/loader.service';
import {DialogService} from '@progress/kendo-angular-dialog';

@Component({
  selector: 'app-accounts',
  imports: [
  ],
  templateUrl: './accounts.component.html',
  styleUrl: './accounts.component.scss'
})
export class AccountsComponent {
  protected accounts: AccountRichDto[] = [];
  protected selectedAccount: AccountRichDto | null = null;

  constructor(private accountService: AccountService,
              private loaderService: LoaderService,
              private dialogService: DialogService) {
  }
}
