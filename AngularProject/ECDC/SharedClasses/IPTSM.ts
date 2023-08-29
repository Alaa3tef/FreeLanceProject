import { Time } from "@angular/common";

export interface IPTSM {
  id: number,

  rigId: number,

  time: Time,

  date: Date,

  trainerName: string,

  numsofTrainees: number,

  subjectTitle: string,

  subjectContent: string,

  isDeleted: boolean,

  userId:string,

  no1:number,
  position1:string,
  name1:string,

  no2:number,
  position2:string,
  name2:string,

  no3:number,
  position3:string,
  name3:string,

  no4:number,
  position4:string,
  name4:string,

  no5:number,
  position5:string,
  name5:string,


}
