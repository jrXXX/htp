 
import Axios from "axios"
import * as BookingType from "../actionTypes";
import * as RAMDA from 'ramda'
 
export const getPayloadFromFailedResponse = error =>{
    const datas = RAMDA.nth(0,error?.response?.data||[])
 
    const responseMessageWithDefault = RAMDA.propOr('Die Buchung hat leider nicht funktioniert!', 'responseMessage');
    const responseMessage = responseMessageWithDefault(datas); 

    const responseStatusWithDefaultValue = RAMDA.propOr(409, 'responseStatus');
    const responseStatus = responseStatusWithDefaultValue(datas); 

    const payload = {
        message: responseMessage||error?.message||"Die Buchung hat leider nicht funktioniert",
        status: responseStatus||400
    }
    return payload
}

export const getPayloadFromSuccededResponse = success =>{

    const datas = RAMDA.nth(0,success?.data||[])
    const responseMessageWithDefault = RAMDA.propOr('Buchung erfolgreich!', 'responseMessage');
    const responseMessage = responseMessageWithDefault(datas); 
    
    const responseStatusWithDefaultValue = RAMDA.propOr(200, 'responseStatus');
    const responseStatus = responseStatusWithDefaultValue(datas); 
 
    console.log("Buchung nachricht : " + responseMessage)
    const payload = {
        message: responseMessage,
        status: responseStatus
    }
    return payload
}


export const bookRoom = (bookRequest) => async dispatch =>{
    dispatch({
        type: BookingType.BOOKING_ROOM_STARTED
    })
    try {
        let _bookingResource = process.env.REACT_APP_BACKEND_BOOKING_RESOURCE || "/roomBooking"
        const booking = await Axios.post(process.env.REACT_APP_BACKEND_HOST+"/" + _bookingResource, bookRequest);
        
        dispatch({
            type: BookingType.BOOKING_ROOM_SUCCEDED,
            payload: getPayloadFromSuccededResponse(booking)
        })
    } catch (error) {
        dispatch({
            type: BookingType.BOOKING_ROOM_FAILED,
            payload: getPayloadFromFailedResponse(error),
        })
    }
}
       
export const setVendorType = (vendor) => async dispatch =>{
    dispatch({
        type: BookingType.SET_VENDOR_TYPE,
        payload: vendor
    })
}