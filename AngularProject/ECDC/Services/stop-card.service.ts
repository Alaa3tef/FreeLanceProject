import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { IAPIResult } from 'SharedClasses/IAPIResult';
import { IAccident } from 'SharedClasses/IAccident';
import { Observable } from 'rxjs';
import { IStopCardRegister } from 'SharedClasses/IStopCardRegister';

@Injectable({
  providedIn: 'root'
})
export class  stopcardservice{

  constructor(private http: HttpClient) { }

  AddStopCardRegister(stopCard: IStopCardRegister): Observable<IStopCardRegister> {
    return this.http.post<IStopCardRegister>(`http://localhost:5000/api/StopCardRegister`, stopCard);
  }
/////////
  GetStopCard(userId:string,userRole:string): Observable<IAPIResult> {
    return this.http.get<IAPIResult>(`http://localhost:5000/api/StopCardRegister/GetDataForExcel?UserId=${userId}&UserRole=${userRole}`);
  }

  GetStopCardByDate(date:Date,userId:string,userRole:string): Observable<IAPIResult> {
    return this.http.get<IAPIResult>(`http://localhost:5000/api/StopCardRegister/GetDataByDate/${date}?UserId=${userId}&UserRole=${userRole}`);
  }

  EditStopCard(stopCard: IStopCardRegister): Observable<IStopCardRegister> {
    return this.http.put<IStopCardRegister>(`http://localhost:5000/api/StopCardRegister/${stopCard.id}`,stopCard);
  }

  GetStopCardById(id: number,userId:string,userRole:string): Observable<IAPIResult> {
    return this.http.get<IAPIResult>(`http://localhost:5000/api/StopCardRegister/Edit/${id}?UserId=${userId}&UserRole=${userRole}`);
  }

  // SearchStopCardById(id:number):Observable<IStopCardRegister>
  // {
  //   return this.http.get<IStopCardRegister>(`http://localhost:5000/api/StopCardRegister/GetDataById/${id}`);
  // }

  GetDataByClassification(classification:string,userId:string,userRole:string):Observable<IAPIResult>{
    return this.http.get<IAPIResult>(`http://localhost:5000/api/StopCardRegister/GetDataByClassification?classification=${classification}&UserId=${userId}&UserRole=${userRole}`);
  }

}
