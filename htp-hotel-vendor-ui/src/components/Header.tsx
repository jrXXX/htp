import  { Component } from "react";
import { Link } from "react-router-dom";
import { FaAlignRight } from "react-icons/fa";
import logo from "../images/logo.svg";
import {connect} from 'react-redux';
import java_image from "../images/JAVA.png";
import _net_image from "../images/.NET.png";

class Header extends Component {
 
  state = {
    isOpen: false,
    vendor : undefined

  };

  static getDerivedStateFromProps(nextProps: any, prevState: any) {
         
        if(prevState.vendor !== nextProps.vendor)
          return {
            vendor: nextProps.vendor
          };

        return null;
  }

  handleToggle = () => {
    this.setState({ isOpen: !this.state.isOpen });
  };
  render() {

    return (
      <nav className="navbar">
        <div className="nav-center">
          <div className="nav-header">
            <Link to="/">
              <img src={logo} alt="Beach Resort" />
            </Link> 

            <button
              type="button"
              className="nav-btn"
              onClick={this.handleToggle}
            >
              <FaAlignRight className="nav-icon" />
            </button>
          </div>
          <ul
            className={this.state.isOpen ? "nav-links show-nav" : "nav-links"}
          >
            <li>
              <Link to="/">Home</Link>
            </li>
            <li>
              <Link to="/rooms">Rooms</Link>
            </li>
          </ul>  
         
 
        </div>
        {this.state.vendor === "JAVA" && <Link to="/">
              <img   className="backendImageInHeader"   src={java_image} alt="Beach Resort" />
            </Link>}
            {this.state.vendor === ".NET" && <Link to="/">
              <img   className="backendImageInHeader"  src={_net_image}  alt="Beach Resort" />
            </Link>}
      </nav>
    );
  }
}
 
 
const mapStateToProps = (state : any) => { 
  return {        
    vendor: state?.homeStore?.vendor,
  };
};

export default connect(mapStateToProps )(Header);