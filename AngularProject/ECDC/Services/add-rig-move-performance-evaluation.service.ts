import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { IAPIResult } from 'SharedClasses/IAPIResult';

import { IRigMovePerformanceEvaluation } from 'SharedClasses/IRigMovePerformanceEvaluation';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class AddRigMovePerformanceEvaluationService {

  constructor(private http: HttpClient) { }

  AddRigMovePerformanceEvaluation(rigPerformance: IRigMovePerformanceEvaluation): Observable<IRigMovePerformanceEvaluation> {
    return this.http.post<IRigMovePerformanceEvaluation>(`http://localhost:5000/api/RigMovePerformance`, rigPerformance);
  }

  GetRigMovePerformanceEvaluationWithData(UserID:string,userRole:string): Observable<IAPIResult> {
    return this.http.get<IAPIResult>(`http://localhost:5000/api/RigMovePerformance/GetAllWithResponseDTO?UserID=${UserID}&UserRole=${userRole}`);
  }

  GetRigMovePerformanceEvaluationWithDataExcel(UserID:string,userRole:string): Observable<IAPIResult> {
    return this.http.get<IAPIResult>(`http://localhost:5000/api/RigMovePerformance/GetAllWithExcelDTO?UserID=${UserID}&UserRole=${userRole}`);
  }


  GetRigMovePerformanceEvaluation(UserId:string,UserRole:string): Observable<IAPIResult> {
    return this.http.get<IAPIResult>(`http://localhost:5000/api/RigMovePerformance?UserID=${UserId}&UserRole=${UserRole}`);
  }

  GetRigMovePerformanceEvaluationById(id:number,UserId:string,UserRole:string): Observable<IAPIResult> {
    return this.http.get<IAPIResult>(`http://localhost:5000/api/RigMovePerformance/${id}?UserID=${UserId}&UserRole=${UserRole}`);
  }


  GetAllRigPerformanceWithDataByDate(Date:Date,UserId:string,UserRole:string): Observable<IAPIResult> {
    return this.http.get<IAPIResult>(`http://localhost:5000/api/RigMovePerformance/GetAllRigPerformanceWithDataByDate/${Date}?UserID=${UserId}&UserRole=${UserRole}`);
  }
}
