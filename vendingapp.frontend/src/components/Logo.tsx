import { useNavigate } from 'react-router-dom'
import logo from '/Logo.png'

export const Logo = () => {

    const navigate = useNavigate();

    return (
        <img className="cursor-pointer"
            src={logo}
            alt="Логотип"
            width={128}
            height={128}
            onClick={() => navigate('/')} />
    )
}