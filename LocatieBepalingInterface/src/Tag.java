import java.util.ArrayList;
import java.util.List;

public class Tag {
    private String tagID;
    private double tagX;
    private double tagY;
    private List<String[]> tagDetails;

    public Tag(String tagID, double tagX, double tagY) {
        this.tagID = tagID;
        this.tagX = tagX;
        this.tagY = tagY;

    }

    public String getTagID() {
        return tagID;
    }

    public double getTagX() {
        return tagX;
    }

    public double getTagY() {
        return tagY;
    }

    public void setTagID(String tagID) {
        this.tagID = tagID;
    }

    public void setTagX(double tagX) {
        this.tagX = tagX;
    }

    public void setTagY(double tagY) {
        this.tagY = tagY;
    }
}
