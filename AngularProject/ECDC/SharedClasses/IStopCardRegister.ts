export interface IStopCardRegister {
  id: number,
  date: Date,
  classificationID: number,
  description: string,
  empCode: number,
  reportedByPositionID: number,
  reportedByNameID: number,
  actionRequired: string,
  typeOfObservationCategoryID: number,
  status: string,
  stopWorkAuthorityApplied: string,
  userID: string,
}
