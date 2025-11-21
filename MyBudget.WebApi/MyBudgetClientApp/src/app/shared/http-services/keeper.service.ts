import {BaseHttpService} from './base-http.service';
import {HttpClient} from '@angular/common/http';
import {Observable} from 'rxjs';
import {Injectable} from '@angular/core';
import {SaveKeeper} from './requests';
import {Guid} from '../common/Guid';
import {KeeperSimpleDto} from './responses';

@Injectable({providedIn: 'root'})
export class KeeperService extends BaseHttpService {
  constructor(http: HttpClient) {
    super('keepers', http);
  }

  public saveKeeper(command: SaveKeeper): Observable<void> {
    return this.post<void>(undefined, command);
  }

  public deleteKeeper(id: Guid): Observable<void> {
    return this.delete<void>(`?id=${id.toString()}`);
  }

  public getKeepers(): Observable<KeeperSimpleDto[]> {
    return this.get();
  }

  public getKeeperById(id: Guid): Observable<KeeperSimpleDto> {
    return this.get(`${id.toString()}`);
  }
}
