import { useEffect, useState } from "react"
import { useNavigate } from "react-router-dom";

export const Profile = () => {

    const [shortMenu, setShortMenu] = useState<boolean>(false)
    const [currentUser, setCurrentUser] = useState<any>(null);
    const navigate = useNavigate();

    const handleExit = () => {
        localStorage.removeItem("user");
        navigate('/login')
    }

    useEffect(() => {
        let user = localStorage.getItem('user')
        if (user) {
            setCurrentUser(JSON.parse(user))
        }
    }, [])


    return (
        <div className="flex flex-col gap-1 p-2 justify-center items-center">

            {currentUser &&

                <ul className="relative flex flex-col gap-1 p-1">
                    <img className="bg-white hover:bg-orange-500 self-end rounded-full"
                        src="icons/angle-right.png"
                        alt=">"
                        height={16}
                        width={16}
                        onClick={() => { setShortMenu(!shortMenu) }} />
                    <li> <img src={currentUser.image}
                        alt="logouser"
                        width={24}
                        height={24} />  {currentUser.fullName} </li>
                    <li> {currentUser.role} </li>
                </ul>}

            {shortMenu && <div className="absolute mr-10 mt-60 flex flex-col gap-1 bg-gray-200 p-3">
                <span> Мои профиль</span>
                <span> Мои сессии</span>
                <span > <button className="hover: bg-amber-400 rounded-2xl p-1" onClick={() => handleExit()}> Выход </button></span>
            </div>}

        </div>
    )
}