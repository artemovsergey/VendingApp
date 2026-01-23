import { useState } from "react"
import { Link } from "react-router-dom"

export const Sidebar = () => {

    const [shortMenu, setShortMenu] = useState<boolean>(false)

    return (

        <aside className="aside w-[30]">

            <img className="bg-white hover:bg-orange-500 self-end rounded-full"
                src="icons/angle-right.png"
                alt=">"
                height={24}
                width={24}
                onClick={() => { setShortMenu(!shortMenu) }} />


            {!shortMenu &&
                <ul>
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