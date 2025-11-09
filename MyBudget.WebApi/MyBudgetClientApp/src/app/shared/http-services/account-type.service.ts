import {BaseHttpService} from './base-http.service';
import {HttpClient} from '@angular/common/http';
import {Observable} from 'rxjs';
import {Injectable} from '@angular/core';
import {AddAccountTypeLinkCommand, DeleteAccountTypeLinkCommand, SaveAccountTypeCommand} from './requests';
import {Guid} from '../common/Guid';
import {AccountTypeRichDto} from './responses';

@Injectable({providedIn: 'root'})
export class AccountTypeService extends BaseHttpService {
  constructor(http: HttpClient) {
    super('account-types', http);
  }

  public saveAccountType(command: SaveAccountTypeCommand): Observable<void> {
    return this.post<void>(undefined, command);
  }

  public addAccountTypeLink(command: AddAccountTypeLinkCommand): Observable<void> {
    return this.post<void>('add-link', command);
  }

  public deleteAccountTypeLink(command: DeleteAccountTypeLinkCommand): Observable<void> {
    return this.post<void>('delete-link', command);
  }

  public getAccountTypes(): Observable<AccountTypeRichDto[]> {
    return this.get();
  }

  public getAccountTypeById(id: Guid): Observable<AccountTypeRichDto> {
    return this.get(`${id.toString()}`);
  }
}
