import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import {Observable, catchError } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class GetdataByPageService {

  constructor(private http: HttpClient) { }
  GetAccidentByPage(pageNumber:number,userId:string,userRole:string):Observable<any>{
    return this.http.get<any>(`http://localhost:5000/api/Accident/ByPage/${pageNumber}?UserId=${userId}&UserRole=${userRole}`);
  }
  GetAccdientCausesByPage(pageNumber:number):Observable<any>{
    return this.http.get<any>(`http://localhost:5000/api/AccidentCauses/ByPage/${pageNumber}`);
  }
  GetClassificationByPage(pageNumber:number):Observable<any>{
    return this.http.get<any>(`http://localhost:5000/api/Classification/ByPage/${pageNumber}`);
  }
  GetClassificationOfAccidentByPage(pageNumber:number):Observable<any>{
    return this.http.get<any>(`http://localhost:5000/api/ClassificationOfAccident/ByPage/${pageNumber}`);
  }
  GetComminucationMethodByPage(pageNumber:number):Observable<any>{
    return this.http.get<any>(`http://localhost:5000/api/ComminucationMethod/ByPage/${pageNumber}`);
  }
  GetDriverByPage(pageNumber:number):Observable<any>{
    return this.http.get<any>(`http://localhost:5000/api/Driver/ByPage/${pageNumber}`);
  }
  GetJMPByPage(pageNumber:number):Observable<any>{
    return this.http.get<any>(`http://localhost:5000/api/JMP/ByPage/${pageNumber}`);
  }
  GetPassengerByPage(pageNumber:number):Observable<any>{
    return this.http.get<any>(`http://localhost:5000/api/Passenger/ByPage/${pageNumber}`);
  }
  GetPreventionCategoryByPage(pageNumber:number):Observable<any>{
    return this.http.get<any>(`http://localhost:5000/api/PreventionCategory/ByPage/${pageNumber}`);
  }
  GetQHSEPositionByPage(pageNumber:number):Observable<any>{
    return this.http.get<any>(`http://localhost:5000/api/QHSEPosition/ByPage/${pageNumber}`);
  }
  GetQHSEPositionNameByPage(pageNumber:number):Observable<any>{
    return this.http.get<any>(`http://localhost:5000/api/QHSEPositionName/ByPage/${pageNumber}`);
  }
  GetReportedByNameByPage(pageNumber:number):Observable<any>{
    return this.http.get<any>(`http://localhost:5000/api/ReportedByName/ByPage/${pageNumber}`);
  }
  GetReportedByPositionByPage(pageNumber:number):Observable<any>{
    return this.http.get<any>(`http://localhost:5000/api/ReportedByPosition/ByPage/${pageNumber}`);
  }
  GetRigByPage(pageNumber:number):Observable<any>{
    return this.http.get<any>(`http://localhost:5000/api/Rig/ByPage/${pageNumber}`);
  }
  GetRouteNameByPage(pageNumber:number):Observable<any>{
    return this.http.get<any>(`http://localhost:5000/api/RouteName/ByPage/${pageNumber}`);
  }
  GetStopCardByPage(pageNumber:number,userId:string,userRole:string):Observable<any>{
    return this.http.get<any>(`http://localhost:5000/api/StopCardRegister/ByPage/${pageNumber}?UserId=${userId}&UserRole=${userRole}`);
  }
  GetToolPusherPositionByPage(pageNumber:number):Observable<any>{
    return this.http.get<any>(`http://localhost:5000/api/ToolPusherPosition/ByPage/${pageNumber}`);
  }
  GetToolPusherPositionNameByPage(pageNumber:number):Observable<any>{
    return this.http.get<any>(`http://localhost:5000/api/ToolPusherPositionName/ByPage/${pageNumber}`);
  }
  GetTypeOfInjuryByPage(pageNumber:number):Observable<any>{
    return this.http.get<any>(`http://localhost:5000/api/TypeOfInjury/ByPage/${pageNumber}`);
  }
  GetTypeOfObservationCategoryByPage(pageNumber:number):Observable<any>{
    return this.http.get<any>(`http://localhost:5000/api/TypeOfObservationCategory/ByPage/${pageNumber}`);
  }
  GetVehicleByPage(pageNumber:number):Observable<any>{
    return this.http.get<any>(`http://localhost:5000/api/Vehicle/ByPage/${pageNumber}`);
  }
  GetViolationCategoryByPage(pageNumber:number):Observable<any>{
    return this.http.get<any>(`http://localhost:5000/api/ViolationCategory/ByPage/${pageNumber}`);
  }


  GetRigMovePerformanceByPage(pageNumber:number,userId:string,userRole:string):Observable<any>{
    return this.http.get<any>(`http://localhost:5000/api/RigMovePerformance/ByPage/${pageNumber}?UserId=${userId}&UserRole=${userRole}`);
  }
}
