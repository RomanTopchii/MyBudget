import {BaseHttpService} from './base-http.service';
import {HttpClient} from '@angular/common/http';
import {Observable} from 'rxjs';
import {Injectable} from '@angular/core';
import {SaveCurrencyCommand, SetAccountingCurrencyCommand} from './requests';
import {Guid} from '../common/Guid';
import {CurrencySimpleDto} from './responses';

@Injectable({providedIn: 'root'})
export class CurrencyService extends BaseHttpService {
  constructor(http: HttpClient) {
    super('currencies', http);
  }

  public saveCurrency(command: SaveCurrencyCommand): Observable<void> {
    return this.post<void>('save', command);
  }

  public setAccountingCurrency(command: SetAccountingCurrencyCommand): Observable<void> {
    return this.post<void>('set-accounting', command);
  }

  public deleteCurrency(id: Guid){
    return this.delete<void>(`?id=${id.toString()}`);
  }

  public getCurrencies(): Observable<CurrencySimpleDto[]>{
    return this.get()
  }

  public getCurrencyById(id: Guid): Observable<CurrencySimpleDto>{
    return this.get(`${id.toString()}`);
  }
}
