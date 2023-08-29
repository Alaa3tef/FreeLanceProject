import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable } from 'rxjs';
import { IAPIResult } from 'SharedClasses/IAPIResult';
import { IJMP } from 'SharedClasses/IJMP';

@Injectable({
  providedIn: 'root'
})
export class AddnewJMPService {
  PendingJMP=new BehaviorSubject<number>(0);

  constructor(private http: HttpClient) { }

  AddJMP(jmp: IJMP): Observable<IJMP> {
    return this.http.post<IJMP>(`http://localhost:5000/api/JMP`, jmp);
  }

  GetJMPs(): Observable<IAPIResult> {
    return this.http.get<IAPIResult>(`http://localhost:5000/api/JMP`);
  }

  GetJMPsForExcel(): Observable<IAPIResult> {
    return this.http.get<IAPIResult>(`http://localhost:5000/api/JMP/GetAllForExcel`);
  }

  GetJMPsByDate(pageNumber:number): Observable<any> {
    return this.http.get<any>(`http://localhost:5000/date/${pageNumber}?pagesize=3`);
  }

  GetJMPBySN(SerialNo:number): Observable<IAPIResult> {
    return this.http.get<IAPIResult>(`http://localhost:5000/api/JMP/SerialNO/${SerialNo}`);
  }

  GetJMPByDateString(date:string): Observable<IAPIResult> {
    return this.http.get<IAPIResult>(`http://localhost:5000/api/JMP/Date/${date}`);
  }
}
