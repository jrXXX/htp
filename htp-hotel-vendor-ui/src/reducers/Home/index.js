import * as BookingType from "../../actions/actionTypes";

const initialState = {
    bookingState: false,
    vendor: undefined
};

const  homeStore = (state = initialState, action) => {
    switch (action.type) {

        case BookingType.BOOKING_ROOM_STARTED:
        case BookingType.BOOKING_ROOM_SUCCEDED:
        case BookingType.BOOKING_ROOM_FAILED:
        {
            return   {   ...state,
                        bookingMessage: action?.payload?.message,
                        bookingResult: action?.payload?.status,
                        bookingState: action.type
                    }
        }

        case BookingType.SET_VENDOR_TYPE:
            {
                return   {   ...state,
                            vendor: action?.payload
                        }
            }
    

        default:
            return state;
    }
}

export default homeStore;
