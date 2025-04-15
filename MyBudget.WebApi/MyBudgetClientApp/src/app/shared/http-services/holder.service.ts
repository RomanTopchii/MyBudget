import {BaseHttpService} from './base-http.service';
import {HttpClient} from '@angular/common/http';
import {Observable} from 'rxjs';
import {Injectable} from '@angular/core';
import {SaveHolderCommand} from './requests';
import {Guid} from '../common/Guid';
import {HolderSimpleDto} from './responses';

@Injectable({providedIn: 'root'})
export class HolderService extends BaseHttpService {
  constructor(http: HttpClient) {
    super('holders', http);
  }

  public saveHolder(command: SaveHolderCommand): Observable<void> {
    return this.post<void>(undefined, command);
  }

  public deleteHolder(id: Guid): Observable<void> {
    return this.delete<void>(`?id=${id.toString()}`);
  }

  public getHolders(): Observable<HolderSimpleDto[]> {
    return this.get();
  }

  public getHolderById(id: Guid): Observable<HolderSimpleDto> {
    return this.get(`${id.toString()}`);
  }
}
