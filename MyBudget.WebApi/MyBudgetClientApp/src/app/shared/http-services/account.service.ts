import {BaseHttpService} from './base-http.service';
import {HttpClient} from '@angular/common/http';
import {Observable} from 'rxjs';
import {Injectable} from '@angular/core';
import {Guid} from '../common/Guid';
import {AccountRichDto} from './responses';
import { SaveAccount } from './requests';

@Injectable({providedIn: 'root'})
export class AccountService extends BaseHttpService {
  constructor(http: HttpClient) {
    super('accounts', http);
  }

  public saveAccount(command: SaveAccount): Observable<void> {
    return this.post<void>(undefined, command);
  }

  public getAccounts(): Observable<AccountRichDto[]> {
    return this.get();
  }

  public getAccountById(id: Guid): Observable<AccountRichDto> {
    return this.get(`${id.toString()}`);
  }
}
