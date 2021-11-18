import React, { Component } from "react";
import { Link } from 'react-router-dom';
import defaultImage from '../images/room-1.jpeg';
import PropTypes, { InferProps } from 'prop-types';

export default function Room({ room }: InferProps<typeof Room.propTypes>){
  
  return <article className="room"> 
  <div className="img-container">
      <img src={room?.images[0] || defaultImage} alt="room" />
      <div className="price-top">
          <h6>${room?.price}</h6>
          <p>per night</p>
      </div>
      <Link to={`/rooms/${room?.slug}`} className="btn-primary room-link">Feagures</Link>
  </div>
  <p className="room-info">{room?.name}</p>
</article>
}

Room.propTypes = {
  room: PropTypes.shape({
      name: PropTypes.string.isRequired,
      slug: PropTypes.string.isRequired,
      images: PropTypes.arrayOf(PropTypes.string).isRequired,
      price: PropTypes.number.isRequired,
  })
}

Room.defaultProps = {
  name: "single-Room",
  slug: "",
  images: [defaultImage],
  price: 20
};