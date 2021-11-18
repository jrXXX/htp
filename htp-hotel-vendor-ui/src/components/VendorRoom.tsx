import React, { FunctionComponent } from "react";
import someContext from "./Context";

type VendorRoomProps = {
  name: string;
};

const VendorRoom: FunctionComponent<VendorRoomProps> = () => {
  return (
    <someContext.Provider
      value={{
        lang: "en",
      }}
    >
      <div>
        <h1>Hello from Vendor Room</h1>
      </div>
    </someContext.Provider>
  );
};

export default VendorRoom;
