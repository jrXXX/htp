import Room from "./Room";
import UserInfo from "./UserInfo";

type BookRoomStateType = {
  userInfo: UserInfo;
  dateFrom: string;
  dateTo: string;
  room: Room;
  vendorType: any
};

export default BookRoomStateType;
