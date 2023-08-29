import { Time } from '@angular/common';
export interface IRigMovePerformanceEvaluation {
  id: number,
  rigId:number,
  userId: string,
  budgetTargetTotalMoney:number,
  budgetTargetTotalDay:number,
  targetArchived: string,
  actualMoveTime:number,
  acceptanceTime:Time,
  releaseTime:Time,
  dieselConsumed:number,
  releaseDate:Date,
  acceptanceDate:Date,
  moveDistance:number,
  oldWellName:string,
  newWellName:string,
  isDeleted: boolean,

  item1:string,
  problemDescription1:string,
  recommendationProblemRepeated1:string,
  timeLostProblem1:number,

  item2:string,
  problemDescription2:string,
  recommendationProblemRepeated2:string,
  timeLostProblem2:number,

  item3:string,
  problemDescription3:string,
  recommendationProblemRepeated3:string,
  timeLostProblem3:number,

  item4:string,
  problemDescription4:string,
  recommendationProblemRepeated4:string,
  timeLostProblem4:number,

  item5:string,
  problemDescription5:string,
  recommendationProblemRepeated5:string,
  timeLostProblem5:number,
}
