import React from "react";
import SidebarP from "./sidebar";
import { Outlet } from "react-router-dom";
import FooterP from "./footer";

function Layout() {
  return (
    <div>
      <div>
        <SidebarP />
      </div>
      <div>{<Outlet />}</div>
    </div>
  );
}

export default Layout;
