package Util;

import java.awt.Component;
import javax.swing.JLabel;
import javax.swing.JTable;
import javax.swing.table.DefaultTableCellRenderer;

public class ContentTableRenderer extends DefaultTableCellRenderer {

    @Override
    public Component getTableCellRendererComponent(JTable jTable,
            Object value,
            boolean isSelected,
            boolean hasFocus,
            int row,
            int col) {
        Component c = super.getTableCellRendererComponent(jTable,
                value,
                isSelected,
                hasFocus,
                row,
                col);
        if ((hasFocus) || (isSelected)) {
            ((JLabel) c).setBorder(DefaultTableCellRenderer.noFocusBorder);
        }

        return c;
    }
}
