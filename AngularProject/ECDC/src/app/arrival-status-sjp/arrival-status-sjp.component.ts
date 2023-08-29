import { Component, SimpleChanges } from '@angular/core';
import { DataService } from 'Services/data.service';
import { EditDataService } from 'Services/edit-data.service';
import { IJMP } from 'SharedClasses/IJMP';
import { BehaviorSubject } from 'rxjs';

@Component({
  selector: 'app-arrival-status-sjp',
  templateUrl: './arrival-status-sjp.component.html',
  styleUrls: ['./arrival-status-sjp.component.scss']
})
export class ArrivalStatusSJPComponent {
  public ListOfSJPs = new BehaviorSubject<any[]>([]);
  readonly SJPsList = this.ListOfSJPs.asObservable();
  page: number = 1;
  count: number = 0;
  productSize: number = 5;
  indexofPages: number = 1;
  countOfPage: number = 0;
  TempArray: any[] = [];

  constructor(private dataService: DataService, private editService: EditDataService) { }

  ngOnInit(): void {
    //Called after the constructor, initializing input properties, and the first call to ngOnChanges.
    //Add 'implements OnInit' to the class.
    this.getpages(1)
  }


  Arrive(id: number, arrivalStatus: boolean, item: IJMP) {
    this.editService.EditArrivalStatus(id, arrivalStatus, item).subscribe({
      next: data => {
        console.log(data)
        this.getpages(this.indexofPages)
      },
      error: err => {
        console.log(err)
      }
    })
  }


  getpages(num: number) {
    this.dataService.GetSJPDataByPage(num).subscribe({
      next: data => {
        this.ListOfSJPs.next(data.items)
        this.countOfPage = data.count;
        this.TempArray = new Array(this.countOfPage);
      },
      error: err => {
        console.log(err)
      }
    })
    this.indexofPages = num;
    console.log("getpages" + this.indexofPages);
  }

  gotleft() {
    (this.indexofPages > 1) ? this.indexofPages -= 1 : this.indexofPages = 1;
    this.getpages(this.indexofPages);
    console.log("gotleft" + this.indexofPages);
  }

  gotoright() {
    (this.indexofPages < this.countOfPage) ? this.indexofPages += 1 : this.indexofPages = this.countOfPage;
    this.getpages(this.indexofPages);
    console.log("gotoright" + this.indexofPages);
  }

}
