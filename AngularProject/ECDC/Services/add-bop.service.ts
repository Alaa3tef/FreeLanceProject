import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { IBOP } from 'SharedClasses/IBOP'
import { IAPIResult } from 'SharedClasses/IAPIResult';


@Injectable({
  providedIn: 'root'
})
export class AddBOPService {

  constructor(private http: HttpClient) { }

  AddBOP(bop: IBOP): Observable<IBOP> {
    return this.http.post<IBOP>(`http://localhost:5000/api/BOP`, bop);
  }


  EditBOP(bopId:number,BOP:IBOP): Observable<IBOP> {
    return this.http.put<IBOP>(`http://localhost:5000/api/BOP/${bopId}`,BOP);
  }

  GetBOPByPage(pageNumber:number,userId:string,userRole:string):Observable<any>{
    return this.http.get<any>(`http://localhost:5000/api/BOP/ByPage/${pageNumber}?UserID=${userId}&UserRole=${userRole}`);
  }

  GetBOP(userId:string,userRole:string):Observable<any>{
    return this.http.get<any>(`http://localhost:5000/api/BOP/GetData?UserID=${userId}&UserRole=${userRole}`);
  }

  GetBOPByDate(date:Date,userId:string,userRole:string):Observable<IAPIResult>{
    return this.http.get<IAPIResult>(`http://localhost:5000/api/BOP/${date}?UserId=${userId}&UserRole=${userRole}`);
  }

  GetBOPForExcel(userId:string,userRole:string):Observable<any>{
    return this.http.get<any>(`http://localhost:5000/api/BOP/GetDataForExcel?UserID=${userId}&UserRole=${userRole}`);
  }

  GeBOPById(id: number,userId:string,UserRole:string): Observable<IAPIResult> {
    return this.http.get<IAPIResult>(`http://localhost:5000/api/BOP/Edit/${id}?UserID=${userId}&UserRole=${UserRole}`);
  }

  DeleteBOP(BOP:IBOP): Observable<IBOP> {
    return this.http.put<IBOP>(`http://localhost:5000/api/BOP/Delete/${BOP.id}`,BOP);
  }
  GetTotalManHours(userId:string,UserRole:string):Observable<IAPIResult>
  {
    return this.http.get<IAPIResult>(`http://localhost:5000/api/BOP/GetTotalManHours?UserID=${userId}&UserRole=${UserRole}`);
  }
}
