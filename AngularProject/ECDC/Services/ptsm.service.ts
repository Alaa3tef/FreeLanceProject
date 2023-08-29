import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { IPTSM } from 'SharedClasses/IPTSM';
import { IAPIResult } from 'SharedClasses/IAPIResult';


@Injectable({
  providedIn: 'root'
})
export class PTSMService {

  constructor(private http: HttpClient) { }

  AddPTSM(ptsm: FormData): Observable<any> {
    return this.http.post<FormData>(`http://localhost:5000/api/PTSM`, ptsm);
  }


  EditPTSM(ptsmId:number,PTSM:IPTSM): Observable<IPTSM> {
    return this.http.put<IPTSM>(`http://localhost:5000/api/PTSM/${ptsmId}`,PTSM);
  }

  GetPTSMByPage(pageNumber:number,userId:string,userRole:string):Observable<any>{
    return this.http.get<any>(`http://localhost:5000/api/PTSM/ByPage/${pageNumber}?UserID=${userId}&UserRole=${userRole}`);
  }

  GetPTSM(userId:string,userRole:string):Observable<any>{
    return this.http.get<any>(`http://localhost:5000/api/PTSM/GetAllWithResponseDTO?UserID=${userId}&UserRole=${userRole}`);
  }

  GetPTSMByDate(date:Date,userId:string,userRole:string):Observable<any>{
    return this.http.get<any>(`http://localhost:5000/api/PTSM/GetAllPTSMWithDataByDate/${date}?UserID=${userId}&UserRole=${userRole}`);
  }

  GetPTSMForExcel(userId:string,userRole:string):Observable<any>{
    return this.http.get<any>(`http://localhost:5000/api/PTSM/GetAllWithExcelDTO?UserID=${userId}&UserRole=${userRole}`);
  }

  GePTSMById(id: number,userId:string,UserRole:string): Observable<IAPIResult> {
    return this.http.get<IAPIResult>(`http://localhost:5000/api/PTSM/${id}?UserID=${userId}&UserRole=${UserRole}`);
  }

  DeletePTSM(PTSM:IPTSM): Observable<IPTSM> {
    return this.http.put<IPTSM>(`http://localhost:5000/api/PTSM/Delete/${PTSM.id}`,PTSM);
  }
}
