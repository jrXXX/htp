import { useState } from "react";
import {connect} from 'react-redux';
import * as PropTypes from 'prop-types'

import { bookRoom, setVendorType } from "../actions/Home";

import imgRoom1 from "../images/room-1.jpeg";
import imgRoom2 from "../images/room-2.jpeg";
import imgRoom4 from "../images/room-4.jpeg";
import imgRoom5 from "../images/room-5.jpeg";
import imgRoom6 from "../images/room-6.jpeg";
import imgRoom10 from "../images/room-10.jpeg";
import imgRoom11 from "../images/room-11.jpeg";
import imgDetails from "../images/details-3.jpeg";
import { BOOKING_ROOM_STARTED } from "../actions/actionTypes";
import { css } from "@emotion/react";
import BarLoader   from "react-spinners/BarLoader";

export function BookRoomForm(props: any) {
  const _search = props.location.search;
  const _roomType = new URLSearchParams(_search).get('roomType');
  const _roomName = new URLSearchParams(_search).get('roomName');
  const _roomId = new URLSearchParams(_search).get('id');
  const _roomPrice = new URLSearchParams(_search).get('roomPrice');
  const _bookFrom = new URLSearchParams(_search).get('bookFrom');
  const _bookTo = new URLSearchParams(_search).get('bookTo');
  const _vendorType = props.vendorType;
  const _portalRef = props.portalRef;
  const _currency = new URLSearchParams(_search).get('currency');
  
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
  const [roomName, ] = useState(_roomName);

  //SINGLE, DOUBLE, TRIPLE, QUAD, QUEEN, KING, TWIN, DOUBLE_DOUBLE, STUDIO
  const [roomType, setRoomType] = useState(_roomType?.toString().toUpperCase());
  const [dateFrom, setDateFrom] = useState(_bookFrom?.toString());
  const [dateTo, setDateTo] = useState(_bookTo?.toString());
  const [roomPrice, setRoomPrice] = useState(_roomPrice?.toString());


  props.setVendorType(_vendorType === "java"?"JAVA":".NET");
  
  const handleSubmit = (evt: any) => {
      evt.preventDefault();
 
      var _bookRequest = {};
      if (_vendorType === "java"){

          _bookRequest = {
            customerName: name,
            customerEmail: email,
            customerPhonenumber: phone,
            dateFrom,
            dateTo,
            portalRef: _portalRef,
            room:{
              id: _roomId,
              price: _roomPrice,
              currency: _currency || "CHF"
            }
          }     
      }else
      {
        _bookRequest = {
          userInfo: {
            names: "Akros Name",
            email: "info@akros.ag",
            phone: "004112457896"
          },
          dateFrom: dateFrom,
          dateTo: dateTo,
          portalRef: _portalRef,
          room: {
            roomName,
            roomType,
            roomPrice,
            id: _roomId,
            price: _roomPrice,
            currency : _currency || "CHF"
          },
        };   
      }

      props.bookRoom(_bookRequest);
  }
  const  singeRoomImg: string[] = [imgRoom1, imgRoom6, imgRoom11, imgRoom5, imgDetails];
  const  doubleRoomImg: string[] = [imgRoom4, imgRoom1, imgRoom2, imgRoom4, imgRoom10, imgDetails];

  const imgs = roomType === "double" ? doubleRoomImg : singeRoomImg;

  const override = css`
  display: block;
  margin: 0 auto;
  border-color: #444444;
`;
let [color] = useState("#3e3e3e");

  return (
    <div className="section">
        <div id="booking-content" >
          <div className="container">
            <div className="row">
              <div className="col-md-5">
                <div className="booking-cta">
                  <h1>Make your reservation</h1>
                  <p>
                    Lorem ipsum dolor sit amet consectetur adipisicing elit.
                    Cupiditate laboriosam numquam at OK2
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

                  <div className="row">
                    <div className="col-md-6">
                      <div className="form-group">
                          <input
                            className="form-control"
                            type="number"
                            value={roomPrice}
                            onChange={e => setRoomPrice(e.target.value)}
                            required
                          />
                        <span className="form-label">Room Price</span>
                      </div>
                    </div>
                  </div>

                    <div className="form-btn"> 
                      <button className="submit-btn">Book Now</button><div className="bookresult">
                      <BarLoader color={color} loading={props.bookingState === BOOKING_ROOM_STARTED} css={override} height={16} width={"100%"} speedMultiplier={0.8} ></BarLoader>
                      {props.bookingResult>=400 && <label className="error-msg">{props.bookingMessage}</label>}
                      {props.bookingResult<400 &&<label className="success-msg">{props.bookingMessage}</label>}

                      </div>
                    </div>


                  </form>
                </div>
              </div>
            </div>
          </div>
        </div>
        {/* Room Details  */}
        <div className="row">
          <div className="col-md-5">
            <section>
              <div className="room-img">
                {imgs.map((item, index) => (
                  <img className="single-room-images" key={index} src={item} alt="images"/>
                ))} 
              </div>
            </section>
          </div>
          <div className="col-md-6">
            <div className="single-room-info">
              <section className="extras">
                <h6>description </h6>
                <p>
                Romantik Hotel Schweizerhof offers panoramic views of the Eiger mountain, an indoor pool, and gourmet cuisine.
                All cable cars can be reached within 5 minutes by the hotel's ski bus.
                The spa area is accessible free of charge and includes a Finnish sauna, a steam bath, showers, and Kneipp basins.
                Swiss gourmet cuisine can be enjoyed in the restaurant, and it is possible to order special kosher, vegan or vegetarian meals. The lounge bar with a fireplace and the garden invite you to unwind.
                Bathrobes and cable TVs can be found in all of the nicely furnished rooms and suites. Most offer panoramic views of the Eiger mountain. On request, prayer rugs are provided.
                </p>
              </section>
              <section className="room-extras">
                <h6>extras </h6>
                <ul className="extras">Plush pillows and breathable bed linens</ul>
                <ul className="extras">Full-sized, pH-balanced toiletries</ul>
                <ul className="extras">Complimentary refreshments</ul>
                <ul className="extras">Soft, oversized bath towels</ul>
                <ul className="extras">Adequate safety/security</ul>
                <ul className="extras">Internet</ul>
              </section>
            </div>
          </div>
        </div>
      </div>
  );
}
 
BookRoomForm.propTypes={
  bookRoom: PropTypes.func.isRequired,
  setVendorType: PropTypes.func.isRequired
}

const mapDispatchToProps = {
   bookRoom, setVendorType
}

const mapStateToProps = (state : any, props: any) => { 

  let homeStore = state?.homeStore;

  // I will keep both type of querring URL Data:
  // the first method is the query them directly at the function
  // and the second methos is querying theses data here in the mapStateToProps block


  // alert(process.env.REACT_APP_BACKEND_HOST)
  const _search = props.location.search;
  const _roomType = new URLSearchParams(_search).get('roomType');
  const _roomId = new URLSearchParams(_search).get('id');
  const _roomPrice = new URLSearchParams(_search).get('roomPrice');
  const _bookFrom = new URLSearchParams(_search).get('bookFrom');
  const _bookTo = new URLSearchParams(_search).get('bookTo');
  const _roomName = new URLSearchParams(_search).get('roomName');
  const _portalRef = new URLSearchParams(_search).get('_ref');

  const _vendorType=process.env.REACT_APP_VENDOR_TYPE
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
    vendorType: (_vendorType || '' as string).trim(),
    portalRef: (_portalRef || '' as string).trim(),
};
};

export default connect(mapStateToProps, mapDispatchToProps )(BookRoomForm);