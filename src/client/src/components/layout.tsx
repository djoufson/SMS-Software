import React from "react";
import SidebarP from "./sidebar";
import { Outlet } from "react-router-dom";
import FooterP from "./footer";

function Layout() {
  return (
    <div>
      <div className="z-10">
        <SidebarP />
      </div>
      <div className="z-0">{<Outlet />}</div>
    </div>
  );
}

export default Layout;
