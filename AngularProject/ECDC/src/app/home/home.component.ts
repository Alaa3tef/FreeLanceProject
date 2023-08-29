import { Component } from '@angular/core';
import { AddnewJMPService } from 'Services/addnew-jmp.service';
import * as moment from 'moment';
import { BehaviorSubject } from 'rxjs';
import { DataService } from '../../../Services/data.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})
export class HomeComponent {
  public ListOfSJPs = new BehaviorSubject<any[]>([]);
  readonly SJPsList = this.ListOfSJPs.asObservable();
  page: number = 1;
  count: number = 0;
  indexofPages: number = 1;
  countOfPage: number = 0;
  TempArray: any[] = [];

  constructor(private jmpService: AddnewJMPService, private dataService: DataService) {}

  ngOnInit(): void {
    this.getpages(1)
  }

  getpages(num: number) {
    this.dataService.GetArrivedSJPDataByPage(num).subscribe({
      next: data => {
        this.ListOfSJPs.next(data.items)
        this.countOfPage = data.count;
        this.TempArray = new Array(this.countOfPage);
        console.log(this.ListOfSJPs.getValue())
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
