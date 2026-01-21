import { Header } from "./components/Header"
import { Home } from "./components/Home"
import { Logo } from "./components/Logo"
import { Main } from "./components/Main"
import { Module } from "./components/Module"
import { Profile } from "./components/Profile"
import { Sidebar } from "./components/Sidebar"

function App() {

  return (
    <div className="app">
      <Header>
        <Logo />
        <Profile />
      </Header>

      <Main>
        <Sidebar />
        <Home>
          <h1> Личный кабинет</h1>
          <div className="blocks">
            <Module title="Эффективность сети" />
            <Module title="Состояние сети" />
            <Module title="Сводка" />
            <Module title="Динамика продаж" />
            <Module title="Новости" />
          </div>
        </Home>
      </Main>

    </div>
  )
}

export default App
