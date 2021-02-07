import { Injectable } from '@angular/core';
import { HttpClient, HttpErrorResponse} from '@angular/common/http';
import { Activity } from '../Components/Models/activity';
import { Observable } from 'rxjs/Observable';
import { catchError } from 'rxjs/operators';
import { of } from 'rxjs/observable/of';

export interface User {
  login: string;
}

@Injectable()
export class ActivityService {

  constructor(private http: HttpClient) { };

  addNewSignUp(newsignup: Activity): Observable<number> {
    return this.http.post<number>('api/AcmeActivity/AddNewRecord', newsignup)
      .pipe(
      catchError(this.handleError<number>('AddNewSignUp'))
      );
  }

  getAllRecords(): Observable<Activity[]> {
    return this.http.get<Activity[]>('api/AcmeActivity/GetAll')
      .pipe(
        catchError(this.handleError<Activity[]>('GetAllRecords'))
    );
  }

  private handleError<T>(operation = 'operation', result?: T) {
    return (error: any): Observable<T> => {
      console.error(error); 
      return of(result as T);
    };
  }

}
