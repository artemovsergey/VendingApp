import { useState } from "react"
import { Link } from "react-router-dom"

export const Sidebar = () => {

    const [shortMenu, setShortMenu] = useState<boolean>(false)
    const [isOpenAdminPanel, setIsOpenAdminPanel] = useState<boolean>(false)

    return (

        <aside className="flex flex-col gap-2 bg-black text-white h-screen p-3">

            <img className="bg-white hover:bg-orange-500 self-end rounded-full"
                src="icons/angle-right.png"
                alt=">"
                height={24}
                width={24}
                onClick={() => { setShortMenu(!shortMenu) }} />


            {!shortMenu &&
                <nav className="p-3 flex flex-col gap-1 items-start  w-[200px]">
                    <Link to="/">Главная</Link>
                    <Link to="/monitoring">Монитор ТА</Link>
                    <button className="cursor-pointer" onClick={() => setIsOpenAdminPanel(!isOpenAdminPanel)} >
                        <span>Администрирование</span>
                        <span> { isOpenAdminPanel ? "-" : "+" } </span>
                    </button>
                    {isOpenAdminPanel && <nav className="flex flex-col ml-5">
                        <Link to="/ta">Торговые автоматы</Link>
                        <Link to="/">Компании</Link>
                        <Link to="/">Модемы</Link>
                        <Link to="/">Дополнительные</Link>
                    </nav>}
                    <a>Детальные отчеты</a>
                    <a> Учет ТМЦ</a>
                </nav>
            }


        </aside >
    )
}