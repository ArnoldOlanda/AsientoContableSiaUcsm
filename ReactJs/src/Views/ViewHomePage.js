import { Box, Typography } from '@material-ui/core'
import escudoUcsm from '../img/Escudo_UCSM.png'

export default function ViewHomePage(){
    return(
        <Box className="Content">
            <img src={escudoUcsm} className="ucsm-logo" alt='logo'/>
            <Typography variant="h4" className="home-text">Bienvenido al sistema de contabilidad UCSM</Typography>
        </Box>
    )
}