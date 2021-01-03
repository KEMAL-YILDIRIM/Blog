import { Box } from '@material-ui/core'
import * as React from 'react'
import NavMenu from '../../components/Nav/NavMenu'

export default (props: { children?: React.ReactNode }) => (
  <React.Fragment>
    <NavMenu />
    <Box>{props.children}</Box>
  </React.Fragment>
)
