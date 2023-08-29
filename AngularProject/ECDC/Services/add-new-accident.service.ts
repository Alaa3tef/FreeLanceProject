import { HttpClient, withRequestsMadeViaParent } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Data } from '@angular/router';
import { IAPIResult } from 'SharedClasses/IAPIResult';
import { IAccident } from 'SharedClasses/IAccident';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class AddNewAccidentService {

  constructor(private http: HttpClient) { }

  AddAccident(accident: FormData): Observable<any> {
    return this.http.post<FormData>(`http://localhost:5000/api/Accident`, accident);
  }

  EditAccident(accident: FormData): Observable<IAccident> {
    return this.http.put<IAccident>(`http://localhost:5000/api/Accident/${accident.get('id')}`, accident);
  }
////////////
  GetAccidents(userId:string,userRole:string): Observable<IAPIResult> {
    return this.http.get<IAPIResult>(`http://localhost:5000/api/Accident/GetDataForExcel?UserID=${userId}&UserRole=${userRole}`);
  }

  // GetAccidentByRigId(RigId: number): Observable<IAPIResult> {
  //   return this.http.get<IAPIResult>(`http://localhost:5000/api/Accident/${RigId}`)
  // }

  GetAccidentByClassi(data:Data,userId:string,userRole:string): Observable<IAPIResult> {
    return this.http.get<IAPIResult>(`http://localhost:5000/api/Accident/GetDataByDate/${data}?UserID=${userId}&UserRole=${userRole}`);
  }

  GetAccidentByID(Id: number,userId:string,userRole:string): Observable<IAPIResult> {
    return this.http.get<IAPIResult>(`http://localhost:5000/api/Accident/${Id}?UserId=${userId}&UserRole=${userRole}`)
  }
}
