import { useState } from "react"
import { Link } from "react-router-dom"

export const Sidebar = () => {

    const [shortMenu, setShortMenu] = useState<boolean>(false)

    return (

        <aside className="flex flex-col gap-2 bg-black text-white h-screen p-3 w-[30]">

            <img className="bg-white hover:bg-orange-500 self-end rounded-full"
                src="icons/angle-right.png"
                alt=">"
                height={24}
                width={24}
                onClick={() => { setShortMenu(!shortMenu) }} />


            {!shortMenu &&
                <ul className="p-3 flex flex-col gap-1">
                    {/* <li>Монитор ТА</li> */}
                    <Link to="/">Главная</Link>
                    <Link to="/monitoring">Монитор ТА</Link>
                    <li>Детальные отчеты</li>
                    <li> Учет ТМЦ</li>
                    <li> Администрирование</li>
                </ul>
            }


        </aside >
    )
}