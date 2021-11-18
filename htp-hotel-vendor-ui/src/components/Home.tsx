import { useState } from "react";
import {connect} from 'react-redux';
import * as PropTypes from 'prop-types'

import { bookRoom } from "../actions/Home";

export function Home(props: any) {
  const _search = props.location.search;
  const _roomType = new URLSearchParams(_search).get('roomType');
  // const _roomName = new URLSearchParams(_search).get('roomName');
  const _roomId = new URLSearchParams(_search).get('roomId');
  // const _roomPrice = new URLSearchParams(_search).get('roomPrice');
  const _bookFrom = new URLSearchParams(_search).get('bookFrom');
  const _bookTo = new URLSearchParams(_search).get('bookTo');
  var _name = ""
  var _email = ""
  var _phone = ""
  var _guestCount = "1"

  if(process.env.NODE_ENV === "development")
  {
    _name = "AKROS AG";
    _email = "info@akros.ch";
    _phone = "004112457896";
    _guestCount = "1";
    
  }
  const [name, setName] = useState(_name);
  const [email, setEmail] = useState(_email);
  const [phone, setPhone] = useState(_phone);
  const [guestCount, setGuestCount] = useState(_guestCount);
  // const [roomName, setRoomName] = useState(_roomName);
  // const [roomPrice, setRoomPrice] = useState(_roomPrice);

  //SINGLE, DOUBLE, TRIPLE, QUAD, QUEEN, KING, TWIN, DOUBLE_DOUBLE, STUDIO
  const [roomType, setRoomType] = useState(_roomType?.toString().toUpperCase());
  const [dateFrom, setDateFrom] = useState(_bookFrom?.toString());
  const [dateTo, setDateTo] = useState(_bookTo?.toString());

  const handleSubmit = (evt: any) => {
      evt.preventDefault();
 
      const _bookRequest = {
        name,
        email,
        phone,
        dateFrom,
        dateTo,
        room:{
          id: _roomId,
           // name: _roomName , // according to the actual java backend, the only relevant information here is the roomId
           // type : roomType, // according to the actual java backend, the only relevant information here is the roomId
           // price: _roomPrice // according to the actual java backend, the only relevant information here is the roomId
        }
      }
      props.bookRoom(_bookRequest);
  }
 
  return (
    <>
      <div id="booking" className="section">
        <div className="section-center">
          <div className="container">
            <div className="row">
              <div className="col-md-5">
                <div className="booking-cta">
                  <h1>Make your reservation</h1>
                  <p>
                    Lorem ipsum dolor sit amet consectetur adipisicing elit.
                    Cupiditate laboriosam numquam at OK
                  </p>
                </div>
              </div>
              <div className="col-md-6 col-md-offset-1">
                <div className="booking-form">
                  <form onSubmit={handleSubmit}>
                    <div className="row">
                      <div className="col-md-6">
                        <div className="form-group">
                          <input className="form-control" type="text" 
                          value={name}
                          onChange={e => setName(e.target.value)}
                          />
                          <span className="form-label">Name</span>
                        </div>
                      </div>
                      <div className="col-md-6">
                        <div className="form-group">
                          <input className="form-control" type="email"                           
                          value={email}
                          onChange={e => setEmail(e.target.value)}
                        />
                          <span className="form-label">Email</span>
                        </div>
                      </div>
                    </div>

                    <div className="row">
                      <div className="col-md-6">
                        <div className="form-group">
                          <input className="form-control" type="tel" 
                              value={phone}
                              onChange={e => setPhone(e.target.value)}
                           />
                          <span className="form-label">Phone</span>
                        </div>
                      </div>
                      <div className="col-md-3 col-sm-6">
                        <div className="form-group">
                          <span className="form-label">Rooms</span>
                          <select className="form-control"
                              value={roomType}
                              onChange={e => setRoomType(e.target.value)}
                          >
                            <option  value="SINGLE">SINGLE Room</option>
                            <option  value="DOUBLE">Double Room</option>
                            <option  value="TRIPLE">Triple Room</option>
                            <option  value="QUAD">Quad Room</option>
                            <option  value="QUEEN">Queen Room</option>
                            <option  value="KING">King Room</option>
                            <option  value="TWIN">Twin Room</option>
                            <option  value="STUDIO">Studio Room</option>
                            <option  value="DOUBLE_DOUBLE">Double Double Room</option>

                          </select>
                          <span className="select-arrow"></span>
                        </div>
                      </div>
                      <div className="col-md-3 col-sm-6">
                        <div className="form-group">
                          <span className="form-label">Guests</span>
                          <select className="form-control"                                                     
                          value={guestCount}
                          onChange={e => setGuestCount(e.target.value)}
                          >
                            <option value="1">1 Person</option>
                            <option value="2">2 Persons</option>
                            <option value="3">3 Persons</option>
                          </select>
                          <span className="select-arrow"></span>
                        </div>
                      </div>
                    </div>
                    <div className="row">
                      <div className="col-md-6">
                        <div className="form-group">
                          <input
                            className="form-control"
                            type="date"
                            value={dateFrom}
                            onChange={e => setDateFrom(e.target.value)}
                            required
                          />
                          <span className="form-label">Check In</span>
                        </div>
                      </div>
                      <div className="col-md-6">
                        <div className="form-group">
                          <input
                            className="form-control"
                            type="date"
                            value={dateTo}
                            onChange={e => setDateTo(e.target.value)}
                            required
                          />
                          <span className="form-label">Check Out</span>
                        </div>
                      </div>
                    </div>
                    <div className="form-btn"> 
                      <button className="submit-btn">Book Now</button>
                      {props.bookingResult>=400 && <label className="error-msg">{props.bookingMessage}</label>}
                      {props.bookingResult<400 &&<label className="success-msg">{props.bookingMessage}</label>}
                    </div>


                  </form>
                </div>
              </div>
            </div>
          </div>
        </div>
      </div>
    </>
  );
}
 
Home.propTypes={
  bookRoom: PropTypes.func.isRequired
}

const mapDispatchToProps = {
   bookRoom 
}

const mapStateToProps = (state : any, props: any) => { 

  let homeStore = state?.homeStore;

  // I will keep both type of querring URL Data:
  // the first method is the query them directly at the function
  // and the second methos is querying theses data here in the mapStateToProps block

  const _search = props.location.search;
  const _roomType = new URLSearchParams(_search).get('roomType');
  const _roomId = new URLSearchParams(_search).get('roomId');
  const _roomPrice = new URLSearchParams(_search).get('roomPrice');
  const _bookFrom = new URLSearchParams(_search).get('bookFrom');
  const _bookTo = new URLSearchParams(_search).get('bookTo');
  const _roomName = new URLSearchParams(_search).get('roomName');

  return {        
    roomId: _roomId,
    roomPrice: _roomPrice,
    bookFrom: _bookFrom,
    bookTo: _bookTo,
    roomType: _roomType,
    roomName: _roomName,
    bookingState: homeStore?.bookingState,
    bookingMessage: homeStore?.bookingMessage,
    bookingResult: homeStore?.bookingResult,
};
};

export default connect(mapStateToProps, mapDispatchToProps )(Home);