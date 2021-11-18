import React from "react";

function BookingForm() {
  return (
    <div id="booking" className="section">
      <div className="section-center">
        <div className="container">
          <div className="row">
            <div className="col-md-5">
              <div className="booking-cta">
                <h1>Make your reservation</h1>
                <p>
                  Lorem ipsum dolor sit amet consectetur adipisicing elit.
                  Cupiditate laboriosam numquam at 
                </p>
              </div>
            </div>
            <div className="col-md-6 col-md-offset-1">
              <div className="booking-form">
                <form>
                  <div className="row">
                    <div className="col-md-6">
                      <div className="form-group">
                        <input className="form-control" type="text" />
                        <span className="form-label">Name</span>
                      </div>
                    </div>
                    <div className="col-md-6">
                      <div className="form-group">
                        <input className="form-control" type="email" />
                        <span className="form-label">Email</span>
                      </div>
                    </div>
                  </div>
                  <div className="row">
                    <div className="col-md-6">
                      <div className="form-group">
                        <input className="form-control" type="tel" />
                        <span className="form-label">Phone</span>
                      </div>
                    </div>
                    <div className="col-md-3 col-sm-6">
                      <div className="form-group">
                        <span className="form-label">Rooms</span>
                        <select className="form-control">
                          <option>Studio</option>
                          <option>Deluxe</option>
                          <option>Apartment</option>
                        </select>
                        <span className="select-arrow"></span>
                      </div>
                    </div>
                    <div className="col-md-3 col-sm-6">
                      <div className="form-group">
                        <span className="form-label">Guests</span>
                        <select className="form-control">
                          <option>1 Person</option>
                          <option>2 Persons</option>
                          <option>3 Persons</option>
                          <option>4 Persons</option>
                        </select>
                        <span className="select-arrow"></span>
                      </div>
                    </div>
                  </div>
                  <div className="row">
                    <div className="col-md-6">
                      <div className="form-group">
                        <input className="form-control" type="date" required />
                        <span className="form-label">Check In</span>
                      </div>
                    </div>
                    <div className="col-md-6">
                      <div className="form-group">
                        <input className="form-control" type="date" required />
                        <span className="form-label">Check Out</span>
                      </div>
                    </div>
                  </div>
                  <div className="form-btn">
                    <button className="submit-btn">Book Now</button>
                  </div>
                </form>
              </div>
            </div>
          </div>
        </div>
      </div>
    </div>
  );
}

export default BookingForm;
