import { Outlet } from "react-router-dom";
import { Header } from "./Header";
import { Logo } from "./Logo";
import { Profile } from "./Profile";
import { Sidebar } from "./Sidebar";
import { Main } from "./Main";

export const Layout = () => {
  return (
    <>
      <div className="flex flex-col">
        <Header>
          <Logo />
          <Profile />
        </Header>

        <Main>
          <Sidebar />
          <Outlet />
        </Main>
      </div>
    </>
  );
};
