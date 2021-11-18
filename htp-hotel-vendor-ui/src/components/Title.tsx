import React from "react";

function Title(
  title:
    | boolean
    | React.ReactChild
    | React.ReactFragment
    | React.ReactPortal
    | null
    | undefined
) {
  return (
    <div className="section-title">
      <h4>{title}</h4>
      <div />
    </div>
  );
}

export default Title;
