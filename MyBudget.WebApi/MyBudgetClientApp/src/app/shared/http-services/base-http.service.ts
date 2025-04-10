import {HttpClient, HttpHeaders} from '@angular/common/http';
import {Observable} from 'rxjs';

export  abstract class BaseHttpService {

  protected readonly headers = new HttpHeaders({"Content-Type": "application/json"});

  private relativePathFull: string="";
  constructor(relativePath: string, private http: HttpClient) {
    this.relativePathFull = 'api/' + relativePath;
  }

  protected get<TResult>(url:string | undefined = undefined): Observable<TResult>{
    return this.http.get<TResult>(this.getPath(url), {headers: this.headers});
  }

  protected post<TResult, TData={}>(url: string | undefined = undefined, data?: TData): Observable<TResult>{
    return this.http.post<TResult>(this.getPath(url), data, {headers: this.headers});
  }

  protected delete<TResult>(url:string | undefined = undefined): Observable<TResult>{
    return this.http.delete<TResult>(this.getPath(url), {headers: this.headers});
  }

  private getPath(url: string | undefined): string{
    return `${this.relativePathFull}${url ? `/${url}` :''}`;
  }
}
